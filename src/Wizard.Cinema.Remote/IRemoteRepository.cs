using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote
{
    public interface IRemoteRepository
    {
        int InsertCinema(Models.Cinema cinema);
    }
}