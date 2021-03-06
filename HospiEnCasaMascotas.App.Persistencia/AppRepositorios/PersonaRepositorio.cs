using System.Collections.Generic;
using HospiEnCasaMascotas.App.Dominio;
using System.Linq;

namespace HospiEnCasaMascotas.App.Persistencia{


    public class PersonaRepositorio : iRepositorioPersona
    {


        private readonly AppContext _appContext = new AppContext();

        // public PersonaRepositorio(AppContext appContext){
        //     _appContext=appContext;
        // }
        public Persona AddPersona(Persona persona)
        {
            var PersonaAdicionada= _appContext.Personas.Add(persona);
            _appContext.SaveChanges();
            return PersonaAdicionada.Entity;
               }

        public void DeletePersona(int idPersona)
        {
            var PersonaEncontrada=_appContext.Personas.FirstOrDefault(p =>p.Id==idPersona);
            if(PersonaEncontrada==null)
            return;
            _appContext.Personas.Remove(PersonaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Persona> GetAllPersona()
        {
            return _appContext.Personas;
        }

        public Persona GetPersona(int idPersona)
        {
            return _appContext.Personas.FirstOrDefault(p =>p.Id==idPersona);
        }

        public Persona UpdatePersona(Persona persona)
        {
            var PersonaEncontrada=_appContext.Personas.FirstOrDefault(p =>p.Id==persona.Id);

            if(PersonaEncontrada!=null)
            {
                PersonaEncontrada.Nombre=persona.Nombre;
                PersonaEncontrada.Apellidos=persona.Apellidos;
                PersonaEncontrada.NumeroTelefono=persona.NumeroTelefono;
                PersonaEncontrada.Genero=persona.Genero;

                _appContext.SaveChanges() ;
                

            }
            return PersonaEncontrada;
        }
    }
}