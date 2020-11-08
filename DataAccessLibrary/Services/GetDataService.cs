﻿using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserDataTasks;

namespace DataAccessLibrary.Services
{
    public class GetDataService
    {
        public static async Task <List<Issue>> LoadAllIssuesAsync()
        {
            List<Issue> issues = new List<Issue>();
            try
            {
                await using (var db = new Context())
                {

                    issues = db.Issue.Include(a => a.Customer).Include(b => b.Category).Include(c => c.Situation)
                        .Include(d => d.Picture).Include(e => e.Comment).ToList();
                    
                }
            }
            catch { }
            return issues;
        }

        public static async Task <List<string>> GetCustomersAsync()
        {
            var customernames = new List<string>();

            try
            {
                await using (var db = new Context())
                {
                    var customer = db.Customer.ToList();
                    foreach (var c in customer)
                    {
                        customernames.Add(c.CustomerName);
                    }
                }
               
            }
            catch { }
            return customernames;
        }
        public static async Task <List<string>> GetCategorysAsync()
        {
            var categorys = new List<string>();

            await using (var db = new Context())
            {
                var category = db.Category.ToList();
                foreach (var c in category)
                {
                    categorys.Add(c.Category1);
                }

                return categorys;
            }
        }

        public static async Task <List<string>> GetSituationsAsync()
        {
            var situations = new List<string>();

            try
            {
                await using (var db = new Context())
                {
                    var situation = db.Situation.ToList();
                    foreach (var s in situation)
                    {
                        situations.Add(s.Situation1);
                    }
                }
            }
            catch { }
            return situations;
        }

        public static async Task <List<Issue>> GetIssueDetailsAsync(int id)
        {
            List<Issue> issue = new List<Issue>();

            try
            {
                await using (var db = new Context())
                {

                    issue = db.Issue.Where(i => i.IssueId == id).Include(a => a.Customer).Include(b => b.Category).Include(c => c.Situation)
                        .Include(d => d.Picture).Include(e => e.Comment).ToList();
                    

                }
            }
            catch { }
            return issue;
        }

    }
}
