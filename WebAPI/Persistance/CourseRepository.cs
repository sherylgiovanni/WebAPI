using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using WebAPI.Models;

namespace WebAPI.Persistance
{
    public class CourseRepository : ICourseRepository
    {
        private readonly NHibernate.ISession _session;

        public CourseRepository(NHibernate.ISession session) {
            _session = session;
        }

        public Course Add(Course course)
        {
            using var transaction = _session.BeginTransaction();
            _session.Save(course);
            transaction.Commit();
            return course;
        }

        public void Delete(string course_id)
        {
            using var transaction = _session.BeginTransaction();
            var course = _session.Get<Course>(course_id);
            if (course != null)
            {
                _session.Delete(course);
                transaction.Commit();
            }
        }

        public Course Get(string course_id)
        {
            return _session.Get<Course>(course_id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _session.Query<Course>().ToList();
        }

        public bool Update(Course course)
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                _session.Update(course);
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