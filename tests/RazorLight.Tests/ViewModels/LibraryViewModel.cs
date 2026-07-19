namespace RazorLight.Tests.ViewModels;

public class Book
{
	public required string Title { get; set; }
	public required DateOnly Published { get; set; }
}

public class Author
{
	public required string Name { get; set; }
	public required Book[] Books { get; set; }
}

public class Person
{
	public required string Name { get; set; }
	public required string[] Phones { get; set; } = [];
}

public class LibraryViewModel
{
	public LibraryViewModel()
	{
		Books = Authors.SelectMany(a => a.Books).ToArray();
	}

	public required string Name { get; set; }
	public Person Librarian { get; private set; } = new Person { Name = "Jay Sanati", Phones = ["123456", "987654"] };

	public Author[] Authors { get; set; } = [
		new Author
		{
			Name = "John Doe",
			Books = [
				new Book { Title = "Book 1", Published = new DateOnly(2020, 1, 1) },
				new Book { Title = "Book 2", Published = new DateOnly(2021, 1, 1) }
			]
		},
		new Author
		{
			Name = "Peter Norton",
			Books = [
				new Book { Title = "Book 3", Published = new DateOnly(2022, 1, 1) },
				new Book { Title = "Book 4", Published = new DateOnly(2023, 1, 1) }
			]
		}
	];
	public Book[] Books { get; set; } = [];
}
