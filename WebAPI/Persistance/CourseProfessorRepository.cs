using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class CourseProfessorRepository : ICourseProfessorRepository
    {
        private readonly NHibernate.ISession _session;

        public CourseProfessorRepository(NHibernate.ISession session) {
            _session = session;
        }

        public CourseProfessor Add(CourseProfessor course_professor)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(course_professor);
            transaction.Commit();
            return course_professor;
        }

        public void Delete(string course_professor_id)
        {
            using var transaction = _session.BeginTransaction();
            var course_professor = _session.Get<CourseProfessor>(course_professor_id);
            if (course_professor != null)
            {
                _session.Delete(course_professor);
                transaction.Commit();
            }
        }

        public CourseProfessor Get(string course_professor_id)
        {
            return _session.Get<CourseProfessor>(course_professor_id);
        }

        public IEnumerable<CourseProfessor> GetAll()
        {
            return _session.Query<CourseProfessor>().ToList();
        }

        public bool Update(CourseProfessor course_professor)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(course_professor);
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