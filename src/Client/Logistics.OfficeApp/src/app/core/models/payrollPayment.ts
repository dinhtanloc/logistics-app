import {Employee} from './employee';
import {Payment} from './payment';


export interface PayrollPayment {
  id: string;
  startDate: string;
  endDate: string;
  payment: Payment;
  employee?: Employee; 
}
