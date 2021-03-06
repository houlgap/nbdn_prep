using System;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this, other) || is_equal_to_non_null_instance_of(other);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return other.title.Equals(this.title);
        }

        public static Criteria<Movie> is_published_by(ProductionStudio studio)
        {
            return Where<Movie>.has_a(x => x.production_studio).equal_to(studio);
        }

        public static Criteria<Movie> is_not_published_by_pixar()
        {
            return new NotCriteria<Movie>(is_published_by(ProductionStudio.Pixar));
        }

        public static Criteria<Movie> is_published_by_pixar_or_disney()
        {
            return is_published_by(ProductionStudio.Pixar).or(
                is_published_by(ProductionStudio.Disney));
        }
    }
}