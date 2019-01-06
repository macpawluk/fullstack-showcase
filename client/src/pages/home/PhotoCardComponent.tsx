import * as React from "react";
import { Card, Image } from "semantic-ui-react";
import myPhoto from "./../../images/my-photo.jpg";

class PhotoCardComponent extends React.PureComponent<{}> {
  public render(): JSX.Element {
    return (
      <Card className="card">
        <Image src={myPhoto} fluid={true} />
        <Card.Content>
          <Card.Header>Maciej Pawluk</Card.Header>
          <Card.Description>Software developer</Card.Description>
        </Card.Content>

        <Card.Content>
          <Card.Meta className="right aligned">
            12 years of experience
          </Card.Meta>
        </Card.Content>
      </Card>
    );
  }
}

export const PhotoCard = PhotoCardComponent;
