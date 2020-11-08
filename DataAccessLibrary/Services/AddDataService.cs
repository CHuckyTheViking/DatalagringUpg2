using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class AddDataService
    {
        public static async Task AddIssueToDBAsync(string issue, DateTime datetime, string comment, string picture, string cstmer, string category, string situation)
        {

            try
            {
                int cstmerid = 0;
                int categoryid = 0;
                int situationid = 0;
                await using (var db = new Context())
                {
                    if (cstmer != null)
                    {
                        try
                        {
                            Customer customer = db.Customer.FirstOrDefault(c => c.CustomerName == cstmer);
                            if (customer != null)
                            {
                                cstmerid = customer.CustomerId;
                            }
                            else
                            {
                                db.Customer.Add(new Customer { CustomerName = cstmer });
                                db.SaveChanges();
                                Customer customeradd = db.Customer.FirstOrDefault(c => c.CustomerName == cstmer);
                                cstmerid = customeradd.CustomerId;

                            }
                        }
                        catch { }
                    }

                    if (category != null)
                    {
                        try
                        {

                            var categoryset = db.Category.FirstOrDefault(cat => cat.Category1 == category);
                            if (categoryset != null)
                            {
                                categoryid = categoryset.CategoryId;
                            }

                        }
                        catch { }
                    }

                    if (situation != null)
                    {
                        try
                        {
                            var situationset = db.Situation.FirstOrDefault(sit => sit.Situation1 == situation);
                            if (situationset != null)
                            {
                                situationid = situationset.SituationId;
                            }
                        }
                        catch { }
                    }

                    Issue newIssue = new Issue();

                    newIssue.Issue1 = issue;
                    newIssue.IssueTime = datetime;
                    newIssue.CustomerId = cstmerid;
                    newIssue.CategoryId = categoryid;
                    newIssue.SituationId = situationid;
                    if (comment != null)
                    {
                        newIssue.Comment.Add(new Comment { Comment1 = comment, CommentTime = datetime });
                    }
                    if (picture != null)
                    {
                        newIssue.Picture.Add(new Picture { Picture1 = picture });
                    }

                    db.Issue.Add(newIssue);
                    await db.SaveChangesAsync();
                }
            }
            catch {  }

        }

        
        public static async Task<string> AddCommentToIssueAsync(int id, string comment, DateTime dateTime)
        {
            string response = null;
            try
            {
                await using (var db = new Context())
                {
                    Comment cmt = new Comment { Comment1 = comment, CommentTime = dateTime, IssueId = id };

                    db.Comment.Add(cmt);
                    await db.SaveChangesAsync();
                    response = "Succes!";
                }
                
            }
            catch 
            {
                
                response = "Failed!";                
            }
            return response;

        }

        public static async Task<string> UpdateCustomerAsync(string issueText, string _customer, string _situation, string _category, int id)
        {
            string response = null;
            try
            {
                if (issueText != null)
                {
                    await using (var db = new Context())
                    {

                        Issue issue = db.Issue.First(i => i.IssueId == id);

                        issue.Issue1 = issueText;
                        await db.SaveChangesAsync();

                    }
                }
                if (_customer != null)
                {
                    await using (var db = new Context())
                    {

                        Customer customer = db.Customer.First(c => c.CustomerName == _customer);

                        int customerId = customer.CustomerId;

                        Issue issue = db.Issue.First(i => i.IssueId == id);

                        issue.CustomerId = customerId;

                        await db.SaveChangesAsync();
                    }
                }
                if (_situation != null)
                {
                    await using (var db = new Context())
                    {

                        Situation situation = db.Situation.First(s => s.Situation1 == _situation);

                        int situationId = situation.SituationId;

                        Issue issue = db.Issue.First(i => i.IssueId == id);

                        issue.SituationId = situationId;

                        await db.SaveChangesAsync();
                    }
                }
                if (_category != null)
                {
                    await using (var db = new Context())
                    {
                        Category category = db.Category.First(c => c.Category1 == _category);

                        int categoryId = category.CategoryId;

                        Issue issue = db.Issue.First(i => i.IssueId == id);

                        issue.CategoryId = categoryId;

                        await db.SaveChangesAsync();
                    }
                }

                response = "Succes!";
            }
            catch 
            {
                response = "Failed!";
            }
            return response;
        }
    }
}
