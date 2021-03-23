using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ürün Listeye Eklendi";
        public static string Deleted = "Ürün Listeden Silindi";
        public static string Updated = "Listede ki Ürün Güncellendi";
        public static string MaintanenceTime = "Sistem Bakımda";
        public static string AddError = "Ürün Eklenemedi";
        public static string GetAll = "Ürünler Getirildi";
        public static string OverCapacity = "10' dan Fazla Araç Eklenemez.";
        public static string SameNameError = "Aynı Model'de araba Eklenemez";
        public static string OverCapatiyForBrand = "15'ten fazla Model eklenirse Yeni Bir Araç Eklenemez. Saçma Ama İş Kuralım Nabam ? :)";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfullLogin = "Başarıyla Giriş Yapıldı.";
        public static string UserAlreadyExist = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullancı başarıyla kaydeldi";
        public static string AccesTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string CarNotFound = "Gönderilen Id'ye göre bir araç bulunamadı";

        public static string CarNotFoundByColorId = "Aradığınız renge göre araç bulunamadı.";

        public static string CarImageLimitExceeded = "Resim yükleme sınırı aşıldı";
    }
}
