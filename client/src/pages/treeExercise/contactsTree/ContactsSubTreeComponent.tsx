import * as React from "react";
import Collapsible from "react-collapsible";
import { List } from "semantic-ui-react";

import { IPersonWithContacts } from "../dataModels";
import { ContactsTreeItem } from "./ContactsTreeItemContainer";

interface IContactsSubTreeComponentProps {
  items: IPersonWithContacts[];
  level: number;
  isDefaultOpen?: boolean;
}

class ContactsSubTreeComponent extends React.PureComponent<
  IContactsSubTreeComponentProps
> {
  public render(): JSX.Element {
    const { items, level, isDefaultOpen } = this.props;
    const style = { marginLeft: `${20 * level}px` };

    const listItems = items.map(item => {
      const header = (
        <ContactsTreeItem
          key={`person_${item.personId}`}
          person={item}
          level={level}
        />
      );

      return (
        <div style={style} key={`treeItem_${item.personId}`}>
          <Collapsible
            trigger={header}
            transitionTime={200}
            lazyRender={true}
            open={isDefaultOpen}
          >
            <ContactsSubTree items={item.contacts} level={level + 1} />
          </Collapsible>
        </div>
      );
    });

    return (
      <List divided={true} relaxed={true}>
        {listItems}
      </List>
    );
  }
}

export const ContactsSubTree = ContactsSubTreeComponent;
