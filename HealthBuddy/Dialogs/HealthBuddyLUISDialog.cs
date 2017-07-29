using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;

using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthBuddy.Dialogs.Common;
using Microsoft.Bot.Builder.Luis.Models;

namespace HealthBuddy
{
    [Serializable]
    [LuisModel("6eef2232-a022-4f57-9ba1-f4f7c6a02f36", "d7c766abf547495ea9b898153f8da85b")]
    public class HealthBuddyLUISDialog: LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            try
            {
                string state;
                bool found = context.UserData.TryGetValue("state", out state);
                if (found && state == "reportloss")
                {
                    ////EntityRecommendation datetimeEntityRecommendation;
                    ////if (result.TryFindEntity(EntityDateTime, out datetimeEntityRecommendation))
                    ////{
                    ////    string bikeid;
                    ////    found = context.UserData.TryGetValue("bikeid", out bikeid);
                    ////    if (!found)
                    ////    {
                    ////        await context.PostAsync(Messages.CannotFindBike);
                    ////        context.Wait(this.MessageReceived);
                    ////        return;
                    ////    }
                    ////    context.UserData.SetValue("state", "reporttime");
                    ////    string message = Messages.CustomerHangon;
                    ////    await context.PostAsync(message);

                    ////    DateTime time;
                    ////    var succeed = DateTime.TryParse(datetimeEntityRecommendation.Resolution["time"], out time);
                    ////    if (!succeed)
                    ////    {
                    ////        await context.PostAsync(Messages.NoValidTime);
                    ////        context.Wait(this.MessageReceived);
                    ////        return;
                    ////    }
                    ////    var oldLoc = await Backend.Bike.LocateBike(bikeid, time);
                    ////    var currentLoc = await Backend.Bike.LocateBike(bikeid);
                    ////    context.UserData.SetValue("lat", oldLoc.latitude);
                    ////    context.UserData.SetValue("lon", oldLoc.longitude);
                    ////    context.UserData.SetValue("addr", oldLoc.name);
                    ////    message = string.Format(Messages.CustomerReplyLocation, result.Query.ToLower(), oldLoc.name, currentLoc.name);
                    ////    var richmessage = context.MakeMessage();
                    ////    richmessage.Text = message;
                    ////    var mapurl = await Backend.BingMapHelper.StaticMapWithRoute(oldLoc, currentLoc);
                    ////    if (mapurl != "")
                    ////    {
                    ////        var heroCard = new HeroCard
                    ////        {
                    ////            Images = new List<CardImage> { new CardImage(mapurl) }
                    ////        };
                    ////        richmessage.Attachments.Add(heroCard.ToAttachment());
                    ////    }
                    ////    await context.PostAsync(richmessage);
                    ////    message = Messages.CustomerAskLocation;
                    ////    await context.PostAsync(message);
                    ////    context.Wait(this.MessageReceived);
                    ////    return;
                    //}
                    //else
                    //{
                    //    context.Wait(this.MessageReceived);
                    //    return;
                    //}
                }
                else
                {
                    string message = string.Format(Messages.None, result.Query);

                    await context.PostAsync(message);

                    context.Wait(this.MessageReceived);
                }
            }
            catch (Exception)
            {
                context.Wait(this.MessageReceived);
            }
        }



        [LuisIntent("welcome")]
        public async Task Welcome(IDialogContext context, IAwaitable<IMessageActivity> activity,  LuisResult result)       
        {
            string name = "";
            string id = "";
            var message = await activity;
            var from = message.From.Id;
            name = message.From.Name;
            string reply = string.Format(Messages.WelcomeText, name);
            await context.PostAsync(reply);
            context.Wait(this.MessageReceived);

            
           
        }

        [LuisIntent("health")]
        public async Task Health(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            string name = "";
            string id = "";
            var message = await activity;
            var from = message.From.Id;
            name = message.From.Name;
            string reply = string.Format(Messages.WelcomeText, name);
            await context.PostAsync(reply);
            context.Wait(this.MessageReceived);



        }

    }
}