using DataAccess.Entities;

namespace Business.Models.Mapping
{
    internal class StatusMapper
    {
        public StatusModel Map(Status from, StatusModel to)
        {
            to.Text = from.Text;

            return to;
        }
    }
}
