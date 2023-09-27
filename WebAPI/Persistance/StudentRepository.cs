using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class StudentRepository : IStudentRepository
    {
        private readonly NHibernate.ISession _session;

        public StudentRepository(NHibernate.ISession session) {
            _session = session;
        }

        public Student Add(Student student)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(student);
            transaction.Commit();
            return student;
        }

        public void Delete(string emplid)
        {
            using var transaction = _session.BeginTransaction();
            var student = _session.Get<Student>(emplid);
            if (student != null)
            {
                _session.Delete(student);
                transaction.Commit();
            }
        }

        public Student Get(string emplid)
        {
            return _session.Get<Student>(emplid);
        }

        public IEnumerable<Student> GetAll()
        {
            return _session.Query<Student>().ToList();
        }

        public bool Update(Student student)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(student);
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}