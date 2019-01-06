import * as React from "react";
import { createSelector } from "reselect";

import { IPersonWithContacts } from "../dataModels";
import { ContactsSubTree } from "./ContactsSubTreeComponent";
import "./ContactsTree.scss";

interface IContactsTreeComponentProps {
  rootPerson: IPersonWithContacts;
}

class ContactsTreeComponent extends React.PureComponent<
  IContactsTreeComponentProps,
  {}
> {
  private createItemsFromRootPerson = createSelector(
    (props: IContactsTreeComponentProps) => props.rootPerson,
    (rootPerson: IPersonWithContacts) => [rootPerson]
  );

  public render(): JSX.Element {
    const items = this.createItemsFromRootPerson(this.props);

    return (
      <div className="tree-view">
        <ContactsSubTree items={items} level={0} isDefaultOpen={true} />
      </div>
    );
  }
}

export const ContactsTree = ContactsTreeComponent;
