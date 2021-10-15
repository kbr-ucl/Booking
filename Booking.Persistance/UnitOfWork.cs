using Booking.Application.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Booking.Persistance
{
    public class UnitOfWork<T,E> : IUnitOfWork<T,E> where T : IRepository<E>
    {
        private BookingContext _context;
        private T _repository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BookingContext context, T repository)
        {
            _context = context;
            _repository = repository;
        }

        public T Repository => _repository;


        public void BeginUnitOfWork()
        {
            _transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot);
        }

        void IUnitOfWork<T, E>.Save(E entity)
        {
            Repository.Save(entity);
        }

        public void CommitUnitOfWork()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw;
            }
        }
    }
}
