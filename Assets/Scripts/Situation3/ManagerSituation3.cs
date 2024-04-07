using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSituation3 : MonoBehaviour
{
	[SerializeField] private List<Book> allBook;
	[SerializeField] private GameObject bookContainer;
	[SerializeField] private BtnBackSituation3 btnBackSituation3;
	[SerializeField] private Button btnBackToRoom;

	public static ManagerSituation3 Instance { get; private set; }

	public List<ExcorsisteTxt> saveTxt = new List<ExcorsisteTxt>();

	private FullScreenBook fullScreenBook = default;

	private void Awake()
	{
		if(Instance != this)
			Instance = this;
	}

	private void Start()
	{
		foreach (var book in allBook)
		{
			book.onClickedBook += Book_onClickedBook;
		}

		btnBackSituation3.onClickedBtnBack += BtnBackSituation3_onClickedBtnBack;
		btnBackSituation3.gameObject.SetActive(false);

		btnBackToRoom.onClick.AddListener(BackToRoom);

		gameObject.SetActive(false);
	}

	private void BackToRoom()
	{
		Transition.TransitionTo(LevelManager.Instance.situation1.gameObject);
		LevelManager.Instance.excorsismeButton.SetActive(true);
	}

	private void BtnBackSituation3_onClickedBtnBack(BtnBackSituation3 sender)
	{
		ActivateBookContainer(true, false);
		btnBackSituation3.gameObject.SetActive(false);
	}

	private void Book_onClickedBook(Book sender, FullScreenBook fullScreenBook)
	{
		this.fullScreenBook = fullScreenBook;
		ActivateBookContainer(false, true);
		btnBackSituation3.gameObject.SetActive(true);
	}

	private void ActivateBookContainer(bool activateBookContainer, bool activateFullScreenBook)
	{
		bookContainer.SetActive(activateBookContainer);
		fullScreenBook.gameObject.SetActive(activateFullScreenBook);
	}

	public void SaveText(List<ExcorsisteTxt> saveTxt)
	{
		this.saveTxt = saveTxt;
	}

	public void Reset_()
	{
		ActivateBookContainer(true, false);
		btnBackSituation3.gameObject.SetActive(false);
	}
}
