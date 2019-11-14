//--------------------------------------------------------------------------------
// <copyright file="User.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase responable de crear un usuario.
    /// </summary>
    public class User : IComponent
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        private string name;

        /// <summary>
        /// Edad del usuario.
        /// </summary>
        private int age;

        /// <summary>
        /// Genero del usuario.
        /// </summary>
        private string genre;

        /// <summary>
        /// Fecha de nacimiento del usuario.
        /// </summary>
        private string birth;

        /// <summary>
        /// Constructor del usuario.
        /// </summary>
        public User()
        {
            this.Name = this.name;
            this.Age = this.age;
            this.Birth = this.birth;
            this.Genre = this.genre;
        }

        /// <summary>
        /// Gets or sets del Sexo del usuario.
        /// </summary>
        /// <value>string.</value>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets del nombre del usuario.
        /// </summary>
        /// <value>String.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets de la edad del usuario.
        /// </summary>
        /// <value>Int.</value>
        public int Age { get; set; }

        /// <summary>
        /// string Fecha de nacimiento del usuario.
        /// </summary>
        /// <value>String.</value>
        public string Birth { get; set; }
    }
}