using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    static class Messages
    {
        public static string Failed = "İşlem başarısız oldu.";
        public static string Successfull = "Başarılı!";
        public static string DescriptionError = "Lütfen en az 20, en çok 250 karakter içeren bir açıklama metni yazınız.";
        public static string MustAddPhoto = "Lütfen en az 1 adet fotoğraf ekleyiniz.";
        public  static string ServiceImageDenied = "Fotoğraf eklenemedi.";
        public static string ServiceImageAdded = "Fotoğraf eklendi.";
        public static string ServiceImageLimitExceeded = "Maksimum 10 adet fotoğraf ekleyebilirsiniz.";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string AccessTokenCreated = "Token Oluşturuldu.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string PasswordError = "Parola hatalı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı kayıt edildi.";
    }
}
