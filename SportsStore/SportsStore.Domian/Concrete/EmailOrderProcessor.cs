// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Net;
using System.Net.Mail;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly EmailSettings _emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailSettings.UseSsl;
                smtpClient.Host = _emailSettings.ServerName;
                smtpClient.Port = _emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                if (_emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                var body =
                    new StringBuilder().AppendLine("A new order has been submitted")
                        .AppendLine("---")
                        .AppendLine("Items：");

                foreach (var cartLine in cart.CartLines)
                {
                    var subtotal = cartLine.Product.Price*cartLine.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})", cartLine.Quantity, cartLine.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? string.Empty)
                    .AppendLine(shippingDetails.Line3 ?? string.Empty)
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? string.Empty)
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

                var mailMessage = new MailMessage(_emailSettings.MailFromAddress, _emailSettings.MailToAddress,
                    "New order submitted!",
                    body.ToString());

                if (_emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}