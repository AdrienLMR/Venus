using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSituation3 : MonoBehaviour
{
	[SerializeField] private List<Book> allBook;
	[SerializeField] private GameObject bookContainer;
	[SerializeField] private GameObject fullscreenBook;

	private void Start()
	{
		foreach (var book in allBook)
		{
			book.onClickedBook += Book_onClickedBook;
		}
	}

	private void Book_onClickedBook(Book sender)
	{
		bookContainer.SetActive(false);
		fullscreenBook.SetActive(true);
	}
}
