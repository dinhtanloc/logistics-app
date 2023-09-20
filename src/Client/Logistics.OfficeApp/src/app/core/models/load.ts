import {LoadStatus} from './loadStatus';
import {Truck} from './truck';

export interface Load {
  id: string;
  refId: number;
  name?: string;
  originAddress: string;
  originCoordinates: string;
  destinationAddress: string;
  destinationCoordinates: string;
  deliveryCost: number;
  distance: number;
  status: LoadStatus;
  dispatchedDate: string;
  pickUpDate: string;
  deliveryDate: string;
  assignedDispatcherId: string;
  assignedDispatcherName: string;
  assignedTruck: Truck;
}
