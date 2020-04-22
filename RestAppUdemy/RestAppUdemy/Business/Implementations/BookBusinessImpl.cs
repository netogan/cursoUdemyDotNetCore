﻿using System.Collections.Generic;
using RestAppUdemy.Data.Coonverters;
using RestAppUdemy.Data.VO;
using RestAppUdemy.Model;
using RestAppUdemy.Repository.Generic;

namespace RestAppUdemy.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);

            bookEntity = _repository.Create(bookEntity);

            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);

            bookEntity = _repository.Create(bookEntity);

            return _converter.Parse(bookEntity);
        }
    }
}
