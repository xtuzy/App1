using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using AndroidX.ConstraintLayout.Widget;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Android.Util;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ConstraintLayout page;

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Console.WriteLine($"[{nameof(this.OnCreate)}]");

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            page = new ConstraintLayout(this) { Id=View.GenerateViewId()};
            page.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            page.SetBackgroundColor(Color.Pink);
            SetContentView(page);

            NotInheritConstraintLayoutClass();
            InheritConstraintLayoutClassConstrainInInit();
            InheritConstraintLayoutClassConstrainAfterInit();
        }

        private void NotInheritConstraintLayoutClass()
        {
            var container = new ContainerConstrainInInit(this) { Id = View.GenerateViewId() };
            container.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)container.LayoutParameters).MatchConstraintMinHeight = 200;
            container.SetBackgroundColor(Color.Red);
            page.AddView(container);

            var view = new LinearLayout(this) { Id = View.GenerateViewId() };
            view.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)view.LayoutParameters).MatchConstraintMinHeight = 200;
            view.SetBackgroundColor(Color.Green);
            container.AddView(view);

            var pageSet = new ConstraintSet();
            pageSet.Clone(page);
            pageSet.Connect(container.Id, ConstraintSet.Left, page.Id, ConstraintSet.Left, 20);
            pageSet.Connect(container.Id, ConstraintSet.Right, page.Id, ConstraintSet.Right, 20);
            pageSet.Connect(container.Id, ConstraintSet.Top, page.Id, ConstraintSet.Top, 100);
            pageSet.ApplyTo(page);

            var containerSet = new ConstraintSet();
            containerSet.Clone(container);
            containerSet.Connect(view.Id, ConstraintSet.Left, container.Id, ConstraintSet.Left, 20);
            containerSet.Connect(view.Id, ConstraintSet.Right, container.Id, ConstraintSet.Right, 20);
            containerSet.Connect(view.Id, ConstraintSet.Top, container.Id, ConstraintSet.Top, 20);
            containerSet.Connect(view.Id, ConstraintSet.Bottom, container.Id, ConstraintSet.Bottom, 20);
            containerSet.ApplyTo(container);
        }

        private void InheritConstraintLayoutClassConstrainInInit()
        {
            var container = new ContainerConstrainInInit(this) { Id = View.GenerateViewId() };
            container.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)container.LayoutParameters).MatchConstraintMinHeight = 200;
            container.SetBackgroundColor(Color.Red);
            page.AddView(container);

            var pageSet = new ConstraintSet();
            pageSet.Clone(page);
            pageSet.Connect(container.Id, ConstraintSet.Left, page.Id, ConstraintSet.Left, 20);
            pageSet.Connect(container.Id, ConstraintSet.Right, page.Id, ConstraintSet.Right, 20);
            pageSet.Connect(container.Id, ConstraintSet.Top, page.Id, ConstraintSet.Top,400);
            pageSet.ApplyTo(page);
        }

        private void InheritConstraintLayoutClassConstrainAfterInit()
        {
            var container = new ContainerConstrainAfterInit(this) { Id = View.GenerateViewId() };
            container.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)container.LayoutParameters).MatchConstraintMinHeight = 200;
            container.SetBackgroundColor(Color.Red);
            page.AddView(container);

            container.layout();

            var pageSet = new ConstraintSet();
            pageSet.Clone(page);
            pageSet.Connect(container.Id, ConstraintSet.Left, page.Id, ConstraintSet.Left, 20);
            pageSet.Connect(container.Id, ConstraintSet.Right, page.Id, ConstraintSet.Right, 20);
            pageSet.Connect(container.Id, ConstraintSet.Top, page.Id, ConstraintSet.Top, 700);
            pageSet.ApplyTo(page);
        }
	}

    public class ContainerConstrainInInit : ConstraintLayout
    {
        public LinearLayout view;

        public ContainerConstrainInInit(Context context) : base(context)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            view = new LinearLayout(context) { Id = View.GenerateViewId() };
            view.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)view.LayoutParameters).MatchConstraintMinHeight = 200;
            view.SetBackgroundColor(Color.Green);
            this.AddView(view);

            layout();
        }

        public  void layout()
        {
            var containerSet = new ConstraintSet();
            containerSet.Clone(this);
            containerSet.Connect(view.Id, ConstraintSet.Left, this.Id, ConstraintSet.Left, 20);
            containerSet.Connect(view.Id, ConstraintSet.Right, this.Id, ConstraintSet.Right, 20);
            containerSet.Connect(view.Id, ConstraintSet.Top, this.Id, ConstraintSet.Top, 20);
            containerSet.Connect(view.Id, ConstraintSet.Bottom, this.Id, ConstraintSet.Bottom, 20);
            containerSet.ApplyTo(this);
        }
    }

    public class ContainerConstrainAfterInit : ConstraintLayout
    {
        public LinearLayout view;

        public ContainerConstrainAfterInit(Context context) : base(context)
        {
            Init(context);
        }

        private void Init(Context context)
        {
            view = new LinearLayout(context) { Id = View.GenerateViewId() };
            view.LayoutParameters = new ConstraintLayout.LayoutParams(0, ViewGroup.LayoutParams.WrapContent);
            ((ConstraintLayout.LayoutParams)view.LayoutParameters).MatchConstraintMinHeight = 200;
            view.SetBackgroundColor(Color.Green);
            this.AddView(view);

            //layout();
        }

        public void layout()
        {
            var containerSet = new ConstraintSet();
            containerSet.Clone(this);
            containerSet.Connect(view.Id, ConstraintSet.Left, this.Id, ConstraintSet.Left, 20);
            containerSet.Connect(view.Id, ConstraintSet.Right, this.Id, ConstraintSet.Right, 20);
            containerSet.Connect(view.Id, ConstraintSet.Top, this.Id, ConstraintSet.Top, 20);
            containerSet.Connect(view.Id, ConstraintSet.Bottom, this.Id, ConstraintSet.Bottom, 20);
            containerSet.ApplyTo(this);
        }
    }
}
