import cx from "classnames";
import * as React from "react";
import { Icon, Message } from "semantic-ui-react";

import "./SlideBanner.scss";

interface ISlideBannerProps {
  header: string;
  show: boolean;
  className?: string;
  onBannerClosed?: () => void;
}

class SlideBannerComponent extends React.PureComponent<ISlideBannerProps> {
  public render(): JSX.Element {
    const { header, show, className, children, onBannerClosed } = this.props;

    return (
      <div className={cx("slide-banner__root", { show }, className)}>
        <Message error={true} className="ui container ">
          <Message.Header>{header}</Message.Header>
          <Message.Content>{children}</Message.Content>

          <div className="close__icon-root" onClick={onBannerClosed}>
            <Icon name="close" size="small" circular={true} />
          </div>
        </Message>
      </div>
    );
  }
}

export const SlideBanner = SlideBannerComponent;
