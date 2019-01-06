export interface IResponse<T> {
  data: T;
}

export interface IResponseWrapper<TRequest, TResponse> {
  request: TRequest;
  response: IResponse<TResponse>;
}
