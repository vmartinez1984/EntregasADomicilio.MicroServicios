﻿//using EntregasADomicilio.Core.Interfaces;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;

namespace EntregasADomicilio.StoreFiles
{
    public class AlmacenDeArchivosFirebase //: IAlmacenadorDeArchivosFirebaseStorage
    {
        string authDomain = "archivos-54624.firebaseapp.com";
        string apikey = "AIzaSyAEnLgwQe4B-zwq-WYx0IMYHIYhcHyCkzw";
        string email = "vmartinez@gmail.com";
        string password = "123456";
        string token;
        string rutaDelStorage = "archivos-54624.appspot.com";

        public Task Borrar(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarArchivo(string ruta, string contenedor, string extension, byte[] bytesDelArchivo)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Guardar(string contenedor, string nombre, IFormFile formFile)
        {
            await ObtenerToken();       
            var downloadURL = await new Firebase.Storage.FirebaseStorage(
                rutaDelStorage,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token),
                    ThrowOnCancel = true
                })
                .Child(contenedor)
                .Child(nombre)                
                .PutAsync(formFile.OpenReadStream()
            );

            return downloadURL;            
        }

        public async Task<byte[]> Obtener(string ruta)
        {
            byte[] bytes = null;
            HttpClient client;

            client = new HttpClient();
            bytes = await client.GetByteArrayAsync(ruta);

            return bytes;
        }

        private async Task ObtenerToken()
        {
            var client = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = apikey,
                AuthDomain = authDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });

            var credenciales = await client.SignInWithEmailAndPasswordAsync(email, password);
            token = await credenciales.User.GetIdTokenAsync();
        }
    }
}