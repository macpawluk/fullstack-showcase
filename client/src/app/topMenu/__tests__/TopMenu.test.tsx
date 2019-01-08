import * as enzyme from "enzyme";
import { shallow } from "enzyme";
import ReactSixteenAdapter from "enzyme-adapter-react-16";
import * as React from "react";
import * as ReactDOM from "react-dom";
import { StaticRouter } from "react-router";
import { RouteComponentProps } from "react-router-dom";

import { TopMenu, TopMenuComponent } from "./../TopMenuComponent";

enzyme.configure({ adapter: new ReactSixteenAdapter() });

describe("TopMenu tests", () => {
  it("renders without crashing", () => {
    const div = document.createElement("div");
    ReactDOM.render(
      <StaticRouter location="/" context={{}}>
        <TopMenu />
      </StaticRouter>,
      div
    );

    ReactDOM.unmountComponentAtNode(div);
  });

  it("sets active home properly", () => {
    const routerProps = {
      location: { pathname: "/" }
    } as RouteComponentProps<{}>;

    const topMenu = shallow(<TopMenuComponent {...routerProps} />);

    const activeLink = topMenu.find("Link.active");

    expect(activeLink.length).toEqual(1);
    expect(activeLink.children().text()).toEqual("Home");
  });

  it("sets active projects properly", () => {
    const routerProps = {
      location: { pathname: "/projects" }
    } as RouteComponentProps<{}>;

    const topMenu = shallow(<TopMenuComponent {...routerProps} />);

    const activeLink = topMenu.find("Link.active");

    expect(activeLink.length).toEqual(1);
    expect(activeLink.children().text()).toEqual("Projects");
  });

  it("sets active tree exercise properly", () => {
    const routerProps = {
      location: { pathname: "/tree-exercise" }
    } as RouteComponentProps<{}>;

    const topMenu = shallow(<TopMenuComponent {...routerProps} />);

    const activeLink = topMenu.find("Link.active");

    expect(activeLink.length).toEqual(1);
    expect(activeLink.children().text()).toEqual("Exercise");
  });
});
