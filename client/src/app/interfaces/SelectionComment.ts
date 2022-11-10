export interface SelectionComment {
  id: string;
  selection: [];
  comment: {
    commentText: string;
    dateCreated: string;
    id: string;
  };
  user: {
    userName: string;
  };
}