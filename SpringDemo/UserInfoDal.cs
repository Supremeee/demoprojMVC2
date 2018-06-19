using System;

namespace SpringDemo
{
    public class UserInfoDal : IUserInfoDal
    {
        public void Show()
        {
            Console.WriteLine("UserInfoDal is writing");
        }
    }
}