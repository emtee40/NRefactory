
// This file has been generated by the GUI designer. Do not modify.
namespace ICSharpCode.NRefactory.GtkDemo
{
	public partial class MainWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.ScrolledWindow scrolledwindow1;
		
		private global::Gtk.TextView textview1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonParse;
		
		private global::Gtk.Button buttonGenerate;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.TreeView treeviewNodes;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ICSharpCode.NRefactory.GtkDemo.MainWindow
			this.Name = "ICSharpCode.NRefactory.GtkDemo.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ICSharpCode.NRefactory.GtkDemo.MainWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			this.textview1 = new global::Gtk.TextView ();
			this.textview1.CanFocus = true;
			this.textview1.Name = "textview1";
			this.scrolledwindow1.Add (this.textview1);
			this.vbox1.Add (this.scrolledwindow1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.scrolledwindow1]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonParse = new global::Gtk.Button ();
			this.buttonParse.CanFocus = true;
			this.buttonParse.Name = "buttonParse";
			this.buttonParse.UseUnderline = true;
			this.buttonParse.Label = global::Mono.Unix.Catalog.GetString ("Parse");
			this.hbox1.Add (this.buttonParse);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonParse]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonGenerate = new global::Gtk.Button ();
			this.buttonGenerate.CanFocus = true;
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.UseUnderline = true;
			this.buttonGenerate.Label = global::Mono.Unix.Catalog.GetString ("Generate");
			this.hbox1.Add (this.buttonGenerate);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonGenerate]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.treeviewNodes = new global::Gtk.TreeView ();
			this.treeviewNodes.CanFocus = true;
			this.treeviewNodes.Name = "treeviewNodes";
			this.GtkScrolledWindow1.Add (this.treeviewNodes);
			this.vbox1.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow1]));
			w7.Position = 2;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
