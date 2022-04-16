import axios from 'axios';

const path =  '/itinerary';

export default {

  getItinerary(itineraryId) {
    return axios.get(path + '/fetch/' + itineraryId)
  },

  getItineraries() {
    return axios.get(path + '/fetch/')
  },

  getItineraryDetails(itineraryId) {
    return axios.get(path + '/fetch/details/' + itineraryId)
  },

  addItinerary(itinerary, userId) {
    return axios.post(path + '/add', itinerary, userId)
  },

  deleteItinerary(itineraryId) {
      return axios.delete(path + '/delete/' + itineraryId)
  },

  deleteLandmarkFromItinerary(itineraryDetails) {
      return axios.delete(path + '/deletelandmark', itineraryDetails)
  },

  addLandmarkToItinerary(itineraryDetails) {
      return axios.post(path + '/addlandmark', itineraryDetails)
  }
}