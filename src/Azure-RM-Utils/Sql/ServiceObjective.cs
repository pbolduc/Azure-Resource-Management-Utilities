namespace ResourceManagement.Extensions.Sql
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class ServiceObjective
    {
        public ServiceObjective(string edition, int dtu, string name, Guid id)
        {
            if (edition == null)
            {
                throw new ArgumentNullException(nameof(edition));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = id;
            Dtu = dtu;
            Name = name;
            Edition = edition;
        }
        public Guid Id { get; }
        public int Dtu { get; }
        public string Name { get; }

        /// <summary>
        /// Gets the database edition.
        /// </summary>
        public string Edition { get; }

        public override bool Equals(object obj)
        {
            return ((ServiceObjective) obj)?.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private string DebuggerDisplay => Name;
    }
}