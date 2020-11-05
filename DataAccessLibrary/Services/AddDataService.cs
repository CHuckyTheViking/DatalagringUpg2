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
        public static async Task AddIssueToDBAsync(string issue, DateTime datetime, string comment, byte[] picture, string cstmer, string category, string situation)
        {
            
            int cstmerid = 0;
            int categoryid = 0;
            int situationid = 0;
            using (var db = new Context())
            {
                if (cstmer != null)
                {
                    try
                    {
                        Customer customer = db.Customer.FirstOrDefault(cus => cus.CustomerName == cstmer);
                        if (customer != null)
                        {
                            cstmerid = customer.CustomerId;
                        }

                    }
                    catch
                    {
                        //STUFF TO ADD A NEW CUSTOMER IF NOT FOUND
                    }
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
                    catch  {}
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
                db.SaveChanges();


            }



        }


    }
}
