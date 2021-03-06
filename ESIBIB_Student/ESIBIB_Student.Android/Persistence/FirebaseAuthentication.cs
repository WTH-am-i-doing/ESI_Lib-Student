﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ESIBIB_Student.Persistence;
using Firebase.Auth;

namespace ESIBIB_Student.Droid.Persistence
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);

                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }


        public string SignUp(string email, string password)
        {
            var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword(email, password);
            return signUpTask.Exception?.Message;
        }

        public string GetUserEmail()
        {
            return FirebaseAuth.Instance.CurrentUser.Email;
        }
    }
}