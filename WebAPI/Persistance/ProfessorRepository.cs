using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly NHibernate.ISession _session;

        public ProfessorRepository(NHibernate.ISession session) {
            _session = session;
        }

        public Professor Add(Professor professor)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(professor);
            transaction.Commit();
            return professor;
        }

        public void Delete(string emplid)
        {
            using var transaction = _session.BeginTransaction();
            var professor = _session.Get<Professor>(emplid);
            if (professor != null)
            {
                _session.Delete(professor);
                transaction.Commit();
            }
        }

        public Professor Get(string emplid)
        {
            return _session.Get<Professor>(emplid);
        }

        public IEnumerable<Professor> GetAll()
        {
            return _session.Query<Professor>().ToList();
        }

        public bool Update(Professor professor)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(professor);
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