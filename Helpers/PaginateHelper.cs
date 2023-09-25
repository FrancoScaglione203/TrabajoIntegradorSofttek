using TrabajoIntegradorSofttek.DTOs;

namespace TrabajoIntegradorSofttek.Helpers
{
    public class PaginateHelper
    {
        /// <summary>
        /// Realiza la paginación de una lista de objetos tipo T y genera un objeto PaginateDataDto.
        /// </summary>
        /// <typeparam name="T">El tipo de elementos contenidos en la lista.</typeparam>
        /// <param name="itemsToPaginate">La lista de elementos a paginar.</param>
        /// <param name="currentPage">El número de página actual.</param>
        /// <param name="url">La URL base utilizada para construir las URL de página anterior y siguiente.</param>
        /// <returns>Un objeto PaginateDataDto que contiene los datos del paginado.</returns>
        public static PaginateDataDto<T> Paginate<T>(List<T> itemsToPaginate, int currentPage, string url)
        {
            int pageSize = 10;
            var totalItems = itemsToPaginate.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
            var nextUrl = currentPage < totalPages ? $"{url}?page={currentPage + 1}" : null;

            return new PaginateDataDto<T>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                PrevUrl = prevUrl,
                NextUrl = nextUrl,
                Items = paginateItems
            };


        }
    }
}
