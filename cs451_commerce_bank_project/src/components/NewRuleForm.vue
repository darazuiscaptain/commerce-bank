<template>
  <div id="new-rule-form-wrapper">
    <router-link to="/notification-rules" class="nav-link">
      <button type="button" class="btn btn-primary btn-pretty">
        ⬅ Back to Rules
      </button>
    </router-link>
    <form>
      <div class="form-group">
        <label for="nameInput">Rule Name:</label>
        <input
          type="text"
          id="nameInput"
          placeholder="Something memorable"
          v-model="name"
          required
        />
      </div>

      <div class="form-group">
        <label for="exampleFormControlSelect2">Rule Type</label>
        <select
          class="form-control"
          id="exampleFormControlSelect2"
          v-model="type"
        >
          <option value="Amount">💰 Amount</option>
          <option value="Location">📍 Location</option>
          <option value="Time">🕖 Time</option>
        </select>
      </div>

      <div v-if="type === 'Amount'" class="form-group">
        <label for="amountGreaterThan" class="control-label">Amount</label
        ><br />
        <input
          id="amountGreaterThan"
          v-model.number="amountGreaterThan"
          placeholder="Enter amount greater than to check for"
          required
        />
      </div>

      <div v-if="type === 'Location'" class="form-group">
        <label for="state" class="control-label">State</label>

        <select
          class="form-control"
          id="state"
          name="state"
          required
          v-model="location"
        >
          <option value="AK">Alaska</option>
          <option value="AL">Alabama</option>
          <option value="AR">Arkansas</option>
          <option value="AZ">Arizona</option>
          <option value="CA">California</option>
          <option value="CO">Colorado</option>
          <option value="CT">Connecticut</option>
          <option value="DC">District of Columbia</option>
          <option value="DE">Delaware</option>
          <option value="FL">Florida</option>
          <option value="GA">Georgia</option>
          <option value="HI">Hawaii</option>
          <option value="IA">Iowa</option>
          <option value="ID">Idaho</option>
          <option value="IL">Illinois</option>
          <option value="IN">Indiana</option>
          <option value="KS">Kansas</option>
          <option value="KY">Kentucky</option>
          <option value="LA">Louisiana</option>
          <option value="MA">Massachusetts</option>
          <option value="MD">Maryland</option>
          <option value="ME">Maine</option>
          <option value="MI">Michigan</option>
          <option value="MN">Minnesota</option>
          <option value="MO">Missouri</option>
          <option value="MS">Mississippi</option>
          <option value="MT">Montana</option>
          <option value="NC">North Carolina</option>
          <option value="ND">North Dakota</option>
          <option value="NE">Nebraska</option>
          <option value="NH">New Hampshire</option>
          <option value="NJ">New Jersey</option>
          <option value="NM">New Mexico</option>
          <option value="NV">Nevada</option>
          <option value="NY">New York</option>
          <option value="OH">Ohio</option>
          <option value="OK">Oklahoma</option>
          <option value="OR">Oregon</option>
          <option value="PA">Pennsylvania</option>
          <option value="PR">Puerto Rico</option>
          <option value="RI">Rhode Island</option>
          <option value="SC">South Carolina</option>
          <option value="SD">South Dakota</option>
          <option value="TN">Tennessee</option>
          <option value="TX">Texas</option>
          <option value="UT">Utah</option>
          <option value="VA">Virginia</option>
          <option value="VT">Vermont</option>
          <option value="WA">Washington</option>
          <option value="WI">Wisconsin</option>
          <option value="WV">West Virginia</option>
          <option value="WY">Wyoming</option>
        </select>
      </div>

      <div>
        <button
          type="button"
          class="btn btn-primary btn-pretty"
          @click="submitRule"
        >
          Submit
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import store from "../store.js";

export default {
  data() {
    return {
      // This will set default field entries
      name: null,
      type: "Location",
      location: "MO",
      amountGreaterThan: -1,
    };
  },
  methods: {
    async submitRule() {
      if (
        !this.name ||
        !this.location ||
        !this.type ||
        !this.amountGreaterThan
      ) {
        return
      }

      const url = `https://localhost:3000/rules/`;

      const data = {
        UserId: store.userId,
        name: this.name,
        location: this.location,
        type: this.type,
        amountGreaterThan: this.amountGreaterThan,
      };

      await fetch(url, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          alert(
            response.ok
              ? "Rule created successfully!"
              : "Rule could not be created."
          );
          this.$router.push("/notification-rules");
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>

<style scoped>
/* TODO: move this to a css file. */
.btn-pretty a {
  color: #fff;
}
.btn-pretty {
  appearance: none;
  backface-visibility: hidden;
  background-color: #006747;
  border-radius: 10px;
  border-style: none;
  box-shadow: none;
  cursor: pointer;
  display: inline-block;
  font-size: 1em;
  font-weight: 500;
  height: 40px;
  letter-spacing: normal;
  line-height: 1.5;
  margin-bottom: 1.5em;
  outline: none;
  overflow: hidden;
  right: 15px;
  text-align: center;
  text-decoration: none;
  transform: translate3d(0, 0, 0);
  transition: all 0.3s;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  vertical-align: top;
  white-space: nowrap;
}
input {
  width: 20em;
}
</style>
