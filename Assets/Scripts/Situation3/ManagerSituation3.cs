using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSituation3 : MonoBehaviour
{
	[SerializeField] private List<Book> allBook;
	[SerializeField] private GameObject bookContainer;
	[SerializeField] private GameObject fullScreenBook;
	[SerializeField] private BtnBackSituation3 btnBackSituation3;

	public static ManagerSituation3 managerSituation3 { get; private set; }

	private void Awake()
	{
		if(managerSituation3 != this)
			managerSituation3 = this;
	}

	private void Start()
	{
		foreach (var book in allBook)
		{
			book.onClickedBook += Book_onClickedBook;
		}

		btnBackSituation3.onClickedBtnBack += BtnBackSituation3_onClickedBtnBack;
		btnBackSituation3.gameObject.SetActive(false);
	}

	private void BtnBackSituation3_onClickedBtnBack(BtnBackSituation3 sender)
	{
		ActivateBookContainer(true, false);
	}

	private void Book_onClickedBook(Book sender)
	{
		ActivateBookContainer(false, true);
		btnBackSituation3.gameObject.SetActive(true);
	}

	private void ActivateBookContainer(bool activateBookContainer, bool activateFullScreenBook)
	{
		bookContainer.SetActive(activateBookContainer);
		fullScreenBook.SetActive(activateFullScreenBook);
	}
}
