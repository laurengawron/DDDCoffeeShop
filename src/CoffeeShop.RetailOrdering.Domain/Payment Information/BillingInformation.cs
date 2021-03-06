﻿using CoffeeShop.Infrastructure;
using CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain
{
    class BillingInformation : ValueObject
    {
        //Do these need to be readonly?
        private PaymentType payment;
        private List<int> cardNumber;
        private DateTime expirationDate;

        BillingInformation(PaymentType newPaymentType, int[] newCardNumber, DateTime newExpirationDate)
        {

            CreditCardValidatorFactory.build(newPaymentType, newCardNumber, newExpirationDate).validate();

            //Only set after we confirm these parameters are valid
            cardNumber = newCardNumber.ToList<int>();
            expirationDate = newExpirationDate;
            payment = newPaymentType;

        }


    }



    public enum PaymentType
    {
        Cash,
        Mastercard,
        Visa
    }

}
