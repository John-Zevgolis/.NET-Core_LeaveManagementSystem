<template>
  <h1>Create Leave Type</h1>
  <hr />
  <form @submit.prevent="createLeaveType">
    <div>
      <input type="text" v-model="form.name" />
      <p v-if="errors.Name">{{ errors.Name[0] }}</p>
    </div>
    <div>
      <input type="number" v-model="form.numberOfDays" />
      <p v-if="errors.NumberOfDays">{{ errors.NumberOfDays[0] }}</p>
    </div>
    <div>
      <button>Create</button>
      <NuxtLink to="/leavetypes">Back to List</NuxtLink>
    </div>
  </form>
</template>

<script setup>
const config = useRuntimeConfig();

const form = reactive({
  name: '',
  numberOfDays: 0,
});

const errors = ref({});

const createLeaveType = async () => {
  try {
    await $fetch(`${config.public.apiBase}/leavetypes`, {
      method: 'POST',
      body: form,
    });
    await navigateTo('/leavetypes');
  } catch (error) {
    if (error.data && error.data.errors) {
      errors.value = error.data.errors;
    } else {
      console.error('Κάποιο άλλο άγνωστο σφάλμα:', error);
    }
  }
};
</script>

<style lang="scss" scoped></style>
