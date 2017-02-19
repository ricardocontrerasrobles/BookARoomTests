using System;

using UIKit;

namespace BookRoomTest.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			table = new UITableView(View.Bounds);
			table.ContentInset = new UIEdgeInsets(30,0,0,0);
			string[] roomItems = new string[40];
			for (int i = 0; i < roomItems.Length; i++)
			{
				int rooomNumber = i + 1;
				roomItems[i] = "Meeting Room " + rooomNumber;
			}
			table.Source = new TableSource(roomItems);
			Add(table);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}

	public class TableSource : UITableViewSource
	{
		string[] itemData;
		string cellIdentifier = "TableCell";
		public TableSource(string[] items)
		{
			itemData = items;
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return itemData.Length;
		}
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = itemData[indexPath.Row];
			cell.DetailTextLabel.Text = "This is a realy nice meeting room.";
			return cell;
		}
	}
}
