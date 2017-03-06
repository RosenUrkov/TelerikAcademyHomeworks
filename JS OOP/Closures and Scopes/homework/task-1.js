/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 V *	Add a new book to category
 V *	Each book has unique title, author and isbn
 V *	It must return the newly created book with assigned ID
 V *	If the category is missing, it must be automatically created
 V *	List all books
 V *	Books are sorted by ID
 V *	This can be done by author, by category or all
 V *	List all categories
 V *	Categories are sorted by ID
 V *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 V *	When adding a book/category, the ID is generated automatically
 V *	Add validation everywhere, where possible
 V *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 V *	Author is any non-empty string
 V *	Unique params are Book title and Book isbn
 V *	Book isbn is an unique code that contains either 10 or 13 digits
 V *	If something is not valid - throw Error
 */
function solve() {
    var library = (function() {
        var books = [],
            categories = [];

        function listBooks(provider) {
            var filtred;
            if (provider !== undefined) {
                if (provider.hasOwnProperty('category')) {
                    filtred = books.filter(x => x.category === provider.category).sort(x => x.ID);
                    return filtred;
                }
                if (provider.hasOwnProperty('author')) {
                    filtred = books.filter(x => x.author === provider.author).sort(x => x.ID);
                    return filtred;
                }
            }
            filtred = books.sort(x => x.ID);
            return filtred;
        }

        function addBook(book) {
            checkBook(book);
            book.ID = books.length + 1;

            if (!categories.some(x => x === book.category)) {
                categories.push(book.category);
            }

            books.push(book);
            return book;
        }

        function checkBook(book) {
            if ((book.title.length < 2 || book.title.length > 100) ||
                (book.category.length < 2 || book.category.length > 100) ||
                (book.isbn.length !== 10 && book.isbn.length !== 13) ||
                (book.author.length === 0) ||
                ((books.some(x => x.title === book.title)) || (books.some(x => x.isbn === book.isbn)))) {

                throw '';
            }
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    })();

    return library;
}

module.exports = solve;