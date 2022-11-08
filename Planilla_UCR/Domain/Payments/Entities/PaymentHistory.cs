using Google.Cloud.Firestore;
namespace Domain.Payments.Entities
{

    [FirestoreData]
    public class PaymentHistory
    {
        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string State { get; set; }

        public PaymentHistory(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

    }
}