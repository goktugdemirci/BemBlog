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
        IDbConnection dbConnection = new SqlConnection(ConnectionString.ConStr);

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
        #endregion
    }
}
