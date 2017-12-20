﻿using System;

using UIKit;
using MapboxDirections;
using CoreLocation;
using Mapbox;
using MapboxNavigation;
using MapboxCoreNavigation;
using MapboxMobileEvents;

namespace NavigationQs
{
    public partial class ViewController : UIViewController
    {
        MGLMapView mapView;
        UIButton routingBtn;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            mapView = new MGLMapView();
            View.AddSubview(mapView);

            routingBtn = new UIButton(UIButtonType.Custom);
            routingBtn.SetTitle("Start", UIControlState.Normal);
            routingBtn.AddTarget(DidTapOnRoutingBtn, UIControlEvent.TouchUpInside);

            View.AddSubview(routingBtn);

            var x = new MMEAPIClient();

            //Directions.shared.calculate(options) {
            //                (waypoints, routes, error) in
            //    guard let route = routes?.first else { return }

            //                let viewController = NavigationViewController(for: route)
            //                    self.present(viewController, animated: true, completion: nil)
            //}
        }

        private void DidTapOnRoutingBtn(object sender, EventArgs e)
        {
            var origin = new MBWaypoint(new CLLocationCoordinate2D(38.9131752, -77.0324047),
            -1,
            "Mapbox");

            var destination = new MBWaypoint(new CLLocationCoordinate2D(38.8977, -77.0365),
                                        -1,
                                             "White House");
            var options = new MBNavigationRouteOptions(
                new MBWaypoint[] { origin, destination },
                MBDirectionsProfileIdentifier.AutomobileAvoidingTraffic
            );
            MBDirections.SharedDirections.CalculateDirectionsWithOptions(
            options,
            (waypoints, route, error) =>
            {

            });
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            mapView.Frame = View.Bounds;
            routingBtn.Frame = new CoreGraphics.CGRect(View.Bounds.Size.Width - 100,
                                                       View.Bounds.Size.Height - 60,
                                                      80,
                                                       40);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
