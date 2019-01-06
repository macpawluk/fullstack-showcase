import { IAction as IActionInternal } from "./Action";
import {
  IResponse as IResponseInternal,
  IResponseWrapper as IResponseWrapperInternal
} from "./ResponseWrapper";
import { IRootState as IRootStateInternal } from "./RootState";

export type IAction = IActionInternal;
export type IRootState = IRootStateInternal;
export type IResponse<T> = IResponseInternal<T>;
export type IResponseWrapper<TRequest, TResponse> = IResponseWrapperInternal<
  TRequest,
  TResponse
>;
