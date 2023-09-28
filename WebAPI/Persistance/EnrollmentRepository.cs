using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly NHibernate.ISession _session;

        public EnrollmentRepository(NHibernate.ISession session) {
            _session = session;
        }

        public Enrollment Add(Enrollment enrollment)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(enrollment);
            transaction.Commit();
            return enrollment;
        }

        public void Delete(string enrollment_id)
        {
            using var transaction = _session.BeginTransaction();
            var enrollment = _session.Get<Enrollment>(enrollment_id);
            if (enrollment != null)
            {
                _session.Delete(enrollment);
                transaction.Commit();
            }
        }

        public Enrollment Get(string enrollment_id)
        {
            return _session.Get<Enrollment>(enrollment_id);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _session.Query<Enrollment>().ToList();
        }

        public bool Update(Enrollment enrollment)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(enrollment);
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