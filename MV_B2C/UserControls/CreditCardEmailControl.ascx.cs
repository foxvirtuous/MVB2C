using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Business.Centers.SalesCenter;

public partial class CreditCardEmailControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private Payment CurrentPayment
    {
        get
        {
            if (Utility.Transaction.CurrentTransactionObject.GetPayments() != null && Utility.Transaction.CurrentTransactionObject.GetPayments().Count > 0)
                return Utility.Transaction.CurrentTransactionObject.GetPayments()[0];
            return null;
        }
    }

    public void BindValueToControls()
    {
        BindOrderPayer();

    }

    private void BindOrderPayer()
    {
        Payment orderPayment = (Payment)CurrentPayment;

        if (orderPayment == null)
        {
            lblPaymentType.Text = "Not by Credit Card";
        }
        else
        {
            TERMS.Common.Person orderPayer = orderPayment.Payer.Person;

            if (orderPayment is CreditCard)
            {
                lblPaymentType.Text = "Credit Card";

                string strTemp = ((CreditCard)orderPayment).CardNumber.Substring(((CreditCard)orderPayment).CardNumber.LastIndexOf("-"));
                if (((CreditCard)orderPayment).CardType == CreditCardType.AmericanExpress)
                    lblCardNumber.Text = "XXXX-XXXXXX" + strTemp;
                else
                    lblCardNumber.Text = "XXXX-XXXX-XXXX" + strTemp;

                lblCreditCard.Text = ((CreditCard)orderPayment).CardType.ToString();
                lblExpirationDate.Text = ((CreditCard)orderPayment).CardExpirationDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                lblCreditCardBankName_Value.Text = ((CreditCard)orderPayment).CreditCardBankName;
                lblCreditCardCustomerServicePhoneNumber_Value.Text = ((CreditCard)orderPayment).CreditCardBankTollFreeNumber;
            }
            else if (orderPayment is Check)
            {
                lblPaymentType.Text = "Check";
            }
            else if (orderPayment is Cash)
            {
                lblPaymentType.Text = "Cash";
            }

            lblPayerLastName.Text = orderPayer.LastName;            

            lblPayerFirstName.Text = orderPayer.FirstName;
            
            lblPayerMiddleName.Text = orderPayer.MiddleName;

            lblCity.Text = orderPayer.Address[0].City.Name.ToString();

            lblState.Text = orderPayer.Address[0].City.ProvinceName;

            lblZip.Text = orderPayer.Address[0].ZipCode;

            lblBillingAddress.Text = orderPayer.Address[0].AddressString;

            lblTel.Text = orderPayer.Phones[0].Number;

            
        }
    }
}
