using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        IDbConnection dbConnection = new SqlConnection(ConnectionString.ConStrLocal);

        #region Validations
        public bool ValidEposta(string eposta)
        {
            if (eposta.Contains('@') && eposta.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string NullveBoslukKontrol(string textInput)
        {
            if (!String.IsNullOrEmpty(textInput))
            {
                int index = -1;
                string text = "";
                for (int i = 0; i < textInput.Length; i++)
                {
                    if (textInput[i] != ' ')
                    {
                        index = i;
                        break;
                    }
                }
                if (index == 0)
                {
                    text = textInput;
                    return text;
                }
                else
                {
                    for (int i = index; i < textInput.Length; i++)
                    {
                        text += textInput[i];
                    }
                    return text;
                }
            }
            else
            {
                return null;
            }
        }
        public bool UniqueEposta(string eposta)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = @eposta", new { eposta });
                if (sayi != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool UniqueKategori(string kategoriAdi)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Kategoriler WHERE KategoriAdi = @kategoriAdi", new { kategoriAdi });
                if (sayi != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion

        #region Giris Metotlari
        public Yonetici GirisYap(string eposta, string sifre)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = @eposta AND Sifre = @sifre AND IsDeleted = 0", new { eposta, sifre });
                if (sayi > 0)
                {
                    Yonetici y = dbConnection.QueryFirst<Yonetici>("SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Yon.Eposta = @eposta", new { eposta });
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public Kullanici KullaniciGirisYap(string eposta, string sifre)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Kullanicilar WHERE Eposta = @eposta AND Sifre = @sifre AND IsDeleted = 0", new { eposta, sifre });
                if (sayi > 0)
                {
                    Kullanici k = dbConnection.QueryFirst<Kullanici>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogumTarihi,IsDeleted FROM Kullanicilar WHERE Eposta = @eposta", new { eposta });
                    return k;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion

        #region Yonetici CRUD
        public List<Yonetici> YoneticiListele(bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Yonetici> yoneticiler = dbConnection.Query<Yonetici>("SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE IsDeleted = @isDeleted", new { isDeleted }).ToList();
                return yoneticiler;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool YoneticiEkle(Yonetici y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Yoneticiler(YetkiID,Adi,Soyadi,KullaniciAdi,Eposta,Sifre,IsDeleted) VALUES(@YetkiID,@Adi,@Soyadi,@KullaniciAdi,@Eposta,@Sifre,@IsDeleted)", y);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool YoneticiSil(int id)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yoneticiler SET IsDeleted = 1 WHERE ID = @id", new { id });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public Yonetici GetYonetici(int id)
        {
            try
            {
                dbConnection.Open();
                Yonetici y = dbConnection.QueryFirst<Yonetici>("SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Yon.ID = @id", new { id });
                return y;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool YoneticiGuncelle(Yonetici y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yoneticiler SET YetkiID=@YetkiID,Adi=@Adi,Soyadi=@Soyadi,KullaniciAdi = @KullaniciAdi,Eposta = @Eposta,Sifre = @Sifre,IsDeleted = @IsDeleted WHERE ID = @ID", y);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion

        #region Kategori CRUD
        public bool KategoriEkle(Kategori k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Kategoriler(KategoriAdi,IsDeleted) VALUES(@KategoriAdi,@IsDeleted)", k);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Kategori> KategoriListele(bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Kategori> kategoriler = dbConnection.Query<Kategori>("SELECT * FROM Kategoriler WHERE IsDeleted = @isDeleted", new { isDeleted }).ToList();
                return kategoriler;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool KategoriSil(int id)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kategoriler SET IsDeleted = 1 WHERE ID = @id", new { id });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public Kategori GetKategori(int id)
        {
            try
            {
                dbConnection.Open();
                Kategori k = dbConnection.QueryFirst<Kategori>("SELECT * FROM Kategoriler WHERE ID = @id", new { id });
                return k;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kategoriler SET KategoriAdi=@KategoriAdi WHERE ID = @ID", k);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion

        #region Makale CRUD
        public bool MakaleEkle(Makale m)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Makaleler(KategoriID,YoneticiID,Baslik,Ozet,TamIcerik,ThumbnailAdi,TamResimAdi,YuklemeTarih,Okundu,IsDeleted) VALUES(@KategoriID,@YoneticiID,@Baslik,@Ozet,@TamIcerik,@ThumbnailAdi,@TamResimAdi,@YuklemeTarih,@Okundu, @IsDeleted)", m);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Makale> MakaleListele()
        {
            try
            {
                dbConnection.Open();
                List<Makale> makaleler = dbConnection.Query<Makale>("SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.TamIcerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarih,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.IsDeleted =0").ToList();
                return makaleler;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool MakaleGuncelle(Makale m)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Makaleler SET KategoriID=@KategoriID,Baslik=@Baslik,Ozet=@Ozet,TamIcerik= @TamIcerik,ThumbnailAdi= @ThumbnailAdi,TamResimAdi= @TamResimAdi,IsDeleted = @IsDeleted WHERE ID = @ID", m);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public Makale GetMakale(int id)
        {
            try
            {
                dbConnection.Open();
                Makale m = dbConnection.QueryFirst<Makale>("SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.TamIcerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarih,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.ID = @id", new { id });
                return m;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Makale> GetMakalesByKategori(int katid)
        {
            try
            {
                dbConnection.Open();
                List<Makale> makaleler = dbConnection.Query<Makale>("SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.TamIcerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarih,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.KategoriID = @katid", new { katid }).ToList();
                return makaleler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool MakaleSil(int id)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Makaleler SET IsDeleted = 1 WHERE ID = @id", new { id });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        #endregion

        #region Kullanıcı CRUD

        public bool KullaniciEkle(Kullanici k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Kullanicilar(KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogumTarihi,IsDeleted) VALUES(@KullaniciAdi,@Eposta,@Sifre,@UyelikTarihi,@DogumTarihi,@IsDeleted)", k);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool KaliciSil(int id)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Kullanicilar WHERE ID=@id", new { id });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool KullaniciGuncelle(Kullanici k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kullanicilar SET KullaniciAdi = @KullaniciAdi,Eposta = @Eposta,Sifre = @Sifre,IsDeleted = @IsDeleted WHERE ID = @ID", k);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool KullaniciGuncelle(int id, bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kullanicilar SET IsDeleted = @IsDeleted WHERE ID = @ID", new { ID = id, IsDeleted = isDeleted });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public List<Kullanici> KullaniciListele(bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Kullanici> kullanicilar = dbConnection.Query<Kullanici>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogumTarihi,IsDeleted FROM Kullanicilar WHERE IsDeleted = @isDeleted", new { isDeleted }).ToList();
                return kullanicilar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Kullanici> KullaniciListele()
        {
            try
            {
                dbConnection.Open();
                List<Kullanici> kullanicilar = dbConnection.Query<Kullanici>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogumTarihi,IsDeleted FROM Kullanicilar").ToList();
                return kullanicilar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public Kullanici KullaniciGetir(int id)
        {
            try
            {
                dbConnection.Open();
                Kullanici k = dbConnection.QueryFirstOrDefault<Kullanici>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogumTarihi,IsDeleted FROM Kullanicilar WHERE ID = @id", new {id});
                return k;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        #endregion

        #region Yorum CRUD
        public bool YorumEkle(Yorum y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Yorumlar (MakaleID,KullaniciID,YorumIcerik,YorumTarihi,IsDeleted) VALUES(@MakaleID,@KullaniciID,@YorumIcerik,@YorumTarihi,@IsDeleted)", y);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Yorum> YorumListele()
        {
            try
            {
                dbConnection.Open();
                List<Yorum> yorumlar = dbConnection.Query<Yorum>("SELECT Yor.ID, Yor.MakaleID, Mak.Baslik, Yor.KullaniciID, Kul.KullaniciAdi, Yor.YorumIcerik, Kat.KategoriAdi,Yor.YorumTarihi, Yor.IsDeleted FROM Yorumlar AS Yor JOIN Makaleler AS Mak ON Yor.MakaleID = Mak.ID JOIN Kullanicilar AS Kul ON Yor.KullaniciID = Kul.ID JOIN Kategoriler AS Kat ON Mak.KategoriID= Kat.ID").ToList();
                return yorumlar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public List<Yorum> YorumListele(int makid)
        {
            try
            {
                dbConnection.Open();
                List<Yorum> yorumlar = dbConnection.Query<Yorum>("SELECT Yor.ID, Yor.MakaleID, Mak.Baslik, Yor.KullaniciID, Kul.KullaniciAdi, Yor.YorumIcerik, Kat.KategoriAdi,Yor.YorumTarihi, Yor.IsDeleted FROM Yorumlar AS Yor JOIN Makaleler AS Mak ON Yor.MakaleID = Mak.ID JOIN Kullanicilar AS Kul ON Yor.KullaniciID = Kul.ID JOIN Kategoriler AS Kat ON Mak.KategoriID= Kat.ID WHERE Yor.IsDeleted = 0 AND Yor.MakaleID = @MakaleID", new { MakaleID = makid }).ToList();
                return yorumlar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public List<Yorum> YorumListele(bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Yorum> yorumlar = dbConnection.Query<Yorum>("SELECT Yor.ID, Yor.MakaleID, Mak.Baslik, Yor.KullaniciID, Kul.KullaniciAdi, Yor.YorumIcerik, Kat.KategoriAdi,Yor.YorumTarihi, Yor.IsDeleted FROM Yorumlar AS Yor JOIN Makaleler AS Mak ON Yor.MakaleID = Mak.ID JOIN Kullanicilar AS Kul ON Yor.KullaniciID = Kul.ID JOIN Kategoriler AS Kat ON Mak.KategoriID= Kat.ID WHERE Yor.IsDeleted = @IsDeleted", new { isDeleted }).ToList();
                return yorumlar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool YorumDurumGuncelle(int id, bool isDeleted)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yorumlar SET IsDeleted = @IsDeleted WHERE ID = @ID", new { ID = id, IsDeleted = isDeleted });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }

        }
        public bool YorumBanla(int KullaniciID)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yorumlar SET IsDeleted = 1 WHERE KullaniciID = @KullaniciID AND IsDeleted = 0", new { KullaniciID });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }


        public bool YorumKaliciSil(int id)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Yorumlar WHERE ID=@id", new { id });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion
    }
}
