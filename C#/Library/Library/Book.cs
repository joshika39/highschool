using System;

namespace Library
{
    
    public class Book
    {
        private readonly int _bookId;
        private String _bookTitle;
        private String _bookWriter;
        private bool _isBorrowed;
        private bool _isReturned;
        private int _borrowedBy; //User Id

        public Book(int bookId, string bookTitle, string bookWriter)
        {
            _bookId = bookId;
            _bookTitle = bookTitle;
            _bookWriter = bookWriter;
        }

        public void Print()
        {
            Console.Write(strings.PropertyID + strings.PropertyTitle + strings.PropertyAuthor, _bookId, _bookTitle, _bookWriter);
            Console.WriteLine();
            Console.WriteLine(strings.PropertyBorrowed, !_isBorrowed ? strings.AnswerNo : strings.AnswerYes);
            
        }
        
        public int BookId => _bookId;

        public int BorrowedBy
        {
            get => _borrowedBy;
            set => _borrowedBy = value;
        }

        public string BookTitle
        {
            get => _bookTitle;
            set => _bookTitle = value;
        }

        public string BookWriter
        {
            get => _bookWriter;
            set => _bookWriter = value;
        }

        public bool IsBorrowed
        {
            get => _isBorrowed;
            set => _isBorrowed = value;
        }

        public bool IsReturned
        {
            get => _isReturned;
            set => _isReturned = value;
        }
    }
}