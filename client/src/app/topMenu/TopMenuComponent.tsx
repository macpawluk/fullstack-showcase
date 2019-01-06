import cx from "classnames";
import * as React from "react";
import { Link, RouteComponentProps, withRouter } from "react-router-dom";
import { Label } from "semantic-ui-react";
import { AppConstants } from "../../shared/AppConstants";
import "./TopMenu.scss";

interface ITopMenuProps extends RouteComponentProps<{}> {}

interface ITopMenuState {
  activeItem: NavItem;
}

enum NavItem {
  Home = 1,
  Projects = 2,
  TreeExercise = 3
}

export class TopMenuComponent extends React.Component<
  ITopMenuProps,
  ITopMenuState
> {
  constructor(props: ITopMenuProps, context: {}) {
    super(props, context);

    this.state = this.getInitialState();
  }

  public componentWillMount(): void {
    this.setNavigationState(this.props);
  }

  public componentWillReceiveProps(newProps: ITopMenuProps): void {
    this.setNavigationState(newProps);
  }

  public render(): JSX.Element {
    const { activeItem } = this.state;

    return (
      <div className="ui top attached tabular menu app-menu-root">
        <div className="ui container">
          <Link
            className={cx(
              "item",
              activeItem === NavItem.Home ? "active" : null
            )}
            to={AppConstants.Routing.Home}
            data-test-id="lnk-home"
          >
            Home
          </Link>
          <Link
            className={cx(
              "item",
              activeItem === NavItem.Projects ? "active" : null
            )}
            to={AppConstants.Routing.Projects}
            data-test-id="lnk-projects"
          >
            Projects
          </Link>
          <Link
            className={cx(
              "item",
              activeItem === NavItem.TreeExercise ? "active" : null
            )}
            to={AppConstants.Routing.TreeExercise}
            data-test-id="lnk-tree-exercise"
          >
            Exercise
          </Link>

          <div className="right menu">
            <Label tag={true} color="teal">
              Showcase
            </Label>
          </div>
        </div>
      </div>
    );
  }

  private setNavigationState = (props: ITopMenuProps) => {
    switch (props.location.pathname) {
      case AppConstants.Routing.Home:
        this.setState({ activeItem: NavItem.Home });
        break;

      case AppConstants.Routing.Projects:
        this.setState({ activeItem: NavItem.Projects });
        break;

      case AppConstants.Routing.TreeExercise:
        this.setState({ activeItem: NavItem.TreeExercise });
        break;
    }
  };

  private getInitialState = (): ITopMenuState => {
    return {
      activeItem: null
    };
  };
}

export const TopMenu = withRouter(TopMenuComponent);
