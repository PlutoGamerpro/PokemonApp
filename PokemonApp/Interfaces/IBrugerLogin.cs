using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Interfaces;

public interface IBrugerLogin
{
    public void CheckLoginInfo(){}
    public bool CheckIfUserExist() { return true; }
}
