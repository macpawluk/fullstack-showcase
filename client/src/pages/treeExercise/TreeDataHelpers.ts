export const buildContactDescription = (contactsCount: number): string => {
  if (!contactsCount) {
    return `0 contacts`;
  }

  if (contactsCount === 1) {
    return `1 contact`;
  }
  return `${contactsCount} contacts`;
};

export const buildNLevelContactDescription = (
  contactsCount: number,
  level: number
): string => {
  if (!contactsCount) {
    return `0 contacts, ${level}-level`;
  }

  if (contactsCount === 1) {
    return `1 contact, ${level}-level`;
  }
  return `${contactsCount} contacts, ${level}-level`;
};
