using System.Data.Entity;

namespace Repository.Implement
{

    internal class DBInitializerCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<EFGenericDBContext>
    {
        protected override void Seed(EFGenericDBContext Context_) => BasicData.Seed(Context_);
    }

    internal class DBInitializerDropCreateDatabaseAlways : DropCreateDatabaseAlways<EFGenericDBContext>
    {
        protected override void Seed(EFGenericDBContext Context_) => BasicData.Seed(Context_);
    }

    internal class DBInitializerDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<EFGenericDBContext>
    {
        protected override void Seed(EFGenericDBContext Context_) => BasicData.Seed(Context_);
    }
}
