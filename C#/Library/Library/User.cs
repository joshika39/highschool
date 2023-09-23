using System;
using System.Collections.Generic;

namespace Library
{
    public class User
    {
        private readonly int _userId;
        private int _userAge;
        private String _userName;
        private String _userEmail;
        private bool _isPremium;
        private List<int> _borrowedBooks = new();

        public User(int userId, int userAge, string userName, string userEmail)
        {
            _userId = userId;
            _userAge = userAge;
            _userName = userName;
            _userEmail = userEmail;
        }

        public void Print()
        {
            Console.WriteLine(strings.PropertyID + strings.PropertyUserName + strings.PropertyAge, _userId, _userName, _userAge);
            Console.WriteLine(strings.PropertyPremium, !_isPremium ? "No" : "Yes");
        }
        public int UserId => _userId;

        public List<int> BorrowedBooks
        {
            get => _borrowedBooks;
            set => _borrowedBooks = value;
        }

        public int UserAge
        {
            get => _userAge;
            set => _userAge = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string UserEmail
        {
            get => _userEmail;
            set => _userEmail = value;
        }

        public bool IsPremium
        {
            get => _isPremium;
            set => _isPremium = value;
        }
    }
}